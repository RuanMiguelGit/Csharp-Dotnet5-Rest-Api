using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Models;
using Microsoft.Extensions.Configuration;


namespace UsuariosApi.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var MensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(MensagemDeEmail);
        }


        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var emailMensagem =new MimeMessage();
            emailMensagem.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            emailMensagem.To.AddRange(mensagem.Destinatario);
            emailMensagem.Subject = mensagem.Assunto;
            emailMensagem.Body =new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return emailMensagem;
        }

        private void Enviar(MimeMessage MensagemDeEmail)
        {
             using var client = new SmtpClient();
            try
            {
                client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    _configuration.GetValue<int>("EmailSettings:Port"), true);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                    _configuration.GetValue<string>("EmailSettings:Password"));
                client.Send(MensagemDeEmail);
            }
            catch { throw; }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

        }
    }
}