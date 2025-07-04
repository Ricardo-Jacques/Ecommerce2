﻿using ECommerce2.Client.Interfaces;
using ECommerce2.Shared.Dtos;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Ecommerce2.Client.Services
{
	public class PaymentTicketService : IPaymentTicketService
	{
		private readonly HttpClient _httpClient;

		public PaymentTicketService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> Post(PaymentTicketDto paymentTicketDto)
		{
			var json = JsonSerializer.Serialize(paymentTicketDto);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("PaymentTicket", content);
			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Erro: " + error);
			}			

			return response.IsSuccessStatusCode;
		}

		public async Task<byte[]?> CreateNewTicket(PaymentTicketDto paymentTicketDto)
		{
			try
			{
				var username = "api-key_T5ttIalQ94NOlJipojqD2fADfR0a9SJ1gqvvbBOmNjw=";
				var password = "token";
				var credentials = $"{username}:{password}";
				var base64Credentials = Convert.ToBase64String(
					System.Text.Encoding.ASCII.GetBytes(credentials));

				_httpClient.DefaultRequestHeaders.Authorization =
					new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

				var form = new Dictionary<string, string>
				{
					["boleto.conta.banco"] = paymentTicketDto.Bank,
					["boleto.conta.agencia"] = paymentTicketDto.Agency,
					["boleto.conta.numero"] = paymentTicketDto.AccountNumber,
					["boleto.conta.carteira"] = paymentTicketDto.Wallet,
					["boleto.beneficiario.nome"] = paymentTicketDto.BeneficiaryName,
					["boleto.beneficiario.cprf"] = paymentTicketDto.BeneficiaryCprf,
					["boleto.beneficiario.endereco.cep"] = paymentTicketDto.BeneficiaryAddressCep,
					["boleto.beneficiario.endereco.uf"] = paymentTicketDto.BeneficiaryAddressUf,
					["boleto.beneficiario.endereco.localidade"] = paymentTicketDto.BeneficiaryAddressLocality,
					["boleto.beneficiario.endereco.bairro"] = paymentTicketDto.BeneficiaryAddressNeighborhood,
					["boleto.beneficiario.endereco.logradouro"] = paymentTicketDto.BeneficiaryAddressStreet,
					["boleto.beneficiario.endereco.numero"] = paymentTicketDto.BeneficiaryAddressNumber,
					["boleto.beneficiario.endereco.complemento"] = paymentTicketDto.BeneficiaryAddresscomplement,

					["boleto.emissao"] = paymentTicketDto.TicketCreated.ToString("yyyy-MM-dd"),
					["boleto.vencimento"] = paymentTicketDto.TicketDueDate.ToString("yyyy-MM-dd"),
					["boleto.documento"] = paymentTicketDto.TicketDocument,
					["boleto.numero"] = paymentTicketDto.TicketNumber,
					["boleto.titulo"] = paymentTicketDto.TicketTitle,
					["boleto.valor"] = paymentTicketDto.TicketValue.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),

					["boleto.pagador.nome"] = paymentTicketDto.PayerName,
					["boleto.pagador.cprf"] = paymentTicketDto.PayerCprf,
					["boleto.pagador.endereco.cep"] = paymentTicketDto.PayerAddressCep,
					["boleto.pagador.endereco.uf"] = paymentTicketDto.PayerAddressUf,
					["boleto.pagador.endereco.localidade"] = paymentTicketDto.PayerAddressLocality,
					["boleto.pagador.endereco.bairro"] = paymentTicketDto.PayerAddressNeighborhood,
					["boleto.pagador.endereco.logradouro"] = paymentTicketDto.PayerAddressStreet,
					["boleto.pagador.endereco.numero"] = paymentTicketDto.PayerAddressNumber,
					["boleto.pagador.endereco.complemento"] = paymentTicketDto.PayerAddresscomplement
				};

				var content = new FormUrlEncodedContent(form);

				var response = await _httpClient.PostAsync("https://sandbox.boletocloud.com/api/v1/boletos", content);
				if (!response.IsSuccessStatusCode)
				{
					var errorContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Erro na requisição:");
					Console.WriteLine(errorContent);
				}

				return await response.Content.ReadAsByteArrayAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao gerar boleto: {ex.Message}");
				return null;
			}
		}

		public async Task<byte[]> GetPaymentTicket(string paymentTicketId)
		{
			var username = "api-key_T5ttIalQ94NOlJipojqD2fADfR0a9SJ1gqvvbBOmNjw=";
			var password = "token";
			var credentials = $"{username}:{password}";
			var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

			_httpClient.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Basic", base64Credentials);

			var url = $"https://sandbox.boletocloud.com/api/v1/boleto/{paymentTicketId}/pdf";
			return await _httpClient.GetByteArrayAsync(url);
		}
	}
}