﻿using System.Net.Mail;
using System.Net;

namespace QA1_SYSTEM.Models
{
    public class EmailService
    {
        public void SendPurchaseRequestNotification(string EmailCC1, string EmailCC2, string EmailCC3, string EmailCC4, string Emailrecipient, string emailSubject, string emailTitle, string message1, string message2)
        {
            string HTML = GetEmailHtmlTemplate();

            string yearNow = DateTime.UtcNow.Year.ToString();
            string title = emailTitle;
            string mensahe1 = message1;
            string mensahe2 = message2;

            HTML = HTML.Replace("{yearNow}", yearNow)
                    .Replace("{mensahe1}", mensahe1)
                    .Replace("{mensahe2}", mensahe2)
                    .Replace("{title}", title);

            MailMessage message = new MailMessage();
            message.Subject = emailSubject;
            message.IsBodyHtml = true;
            message.From = new MailAddress("sdp.system@outlook.ph", "QA1 System Automatic Notification");
            message.Priority = MailPriority.High;
            message.Body = HTML;

            // Add recipient
            if (!string.IsNullOrWhiteSpace(Emailrecipient))
            {
                message.To.Add(new MailAddress(Emailrecipient));
            }

            // Add CC recipients
            if (!string.IsNullOrWhiteSpace(EmailCC1))
            {
                message.CC.Add(new MailAddress(EmailCC1));
            }
            if (!string.IsNullOrWhiteSpace(EmailCC2))
            {
                message.CC.Add(new MailAddress(EmailCC2));
            }
            if (!string.IsNullOrWhiteSpace(EmailCC3))
            {
                message.CC.Add(new MailAddress(EmailCC3));
            }
            if (!string.IsNullOrWhiteSpace(EmailCC4))
            {
                message.CC.Add(new MailAddress(EmailCC4));
            }

            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);
        }

        

        private string GetEmailHtmlTemplate()
        {
            // You can read your HTML template from a file or another source
            // and return it as a string.
            // Example: File.ReadAllText("path/to/email-template.html");

            return @"<!DOCTYPE html>
            <html>
                    <head>
                    <title></title>
                    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type""/>
                    <meta content=""width=device-width, initial-scale=1.0"" name=""viewport""/><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
                    <link href=""https://fonts.googleapis.com/css?family=Montserrat"" rel=""stylesheet"" type=""text/css""/>
                    <link href=""https://fonts.googleapis.com/css?family=Playfair+Display"" rel=""stylesheet"" type=""text/css""/><!--<![endif]-->
                    <style>
                            * {
                                box-sizing: border-box;
                            }

                            body {
                                margin: 0;
                                padding: 0;
                            }

                            a[x-apple-data-detectors] {
                                color: inherit !important;
                                text-decoration: inherit !important;
                            }

                            #MessageViewBody a {
                                color: inherit;
                                text-decoration: none;
                            }

                            p {
                                line-height: inherit
                            }

                            .desktop_hide,
                            .desktop_hide table {
                                mso-hide: all;
                                display: none;
                                max-height: 0px;
                                overflow: hidden;
                            }

                            .image_block img+div {
                                display: none;
                            }

                            @media (max-width:700px) {

                                .desktop_hide table.icons-inner,
                                .social_block.desktop_hide .social-table {
	                                display: inline-block !important;
                                }

                                .icons-inner {
	                                text-align: center;
                                }

                                .icons-inner td {
	                                margin: 0 auto;
                                }

                                .row-content {
	                                width: 100% !important;
                                }

                                .mobile_hide {
	                                display: none;
                                }

                                .stack .column {
	                                width: 100%;
	                                display: block;
                                }

                                .mobile_hide {
	                                min-height: 0;
	                                max-height: 0;
	                                max-width: 0;
	                                overflow: hidden;
	                                font-size: 0px;
                                }

                                .desktop_hide,
                                .desktop_hide table {
	                                display: table !important;
	                                max-height: none !important;
                                }
                            }
                        </style>
                    </head>
                    <body style=""background-color: #ffffff; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nl-container"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff;"" width=""100%"">
                    <tbody>
                    <tr>
                    <td>
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-1"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tbody>
                    <tr>
                    <td>
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #1e1e1e; color: #000000; width: 680px;"" width=""680"">
                    <tbody>
                    <tr>
                    <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-1"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""width:100%;text-align:center;"">
                    <h1 style=""margin: 0; color: #ffffff; font-size: 11px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;"">****THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL****</h1>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </tbody>
                    </table>
                    </td>
                    </tr>
                    </tbody>
                    </table>
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tbody>
                    <tr>
                    <td>
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f7f7f7; background-position: top center; color: #000000; width: 680px;"" width=""680"">
                    <tbody>
                    <tr>
                    <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-left: 60px; padding-right: 60px; padding-top: 30px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                    <div class=""spacer_block block-1"" style=""height:30px;line-height:30px;font-size:1px;""> </div>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""text-align:center;width:100%;"">
                    <h2 style=""margin: 0; color: #000000; direction: ltr; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; font-size: 16px; font-weight: normal; letter-spacing: 1px; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;""><span class=""tinyMce-placeholder"">Quality Assurance 1</span></h2>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:10px;text-align:center;width:100%;"">
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">{title}</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #000000; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 12px; text-align: left; mso-line-height-alt: 21px;""> {mensahe1} </p>
                    <p style=""margin: 0; font-size: 12px; text-align: left; mso-line-height-alt: 21px;""> {mensahe2} </p>
                    </div>
                    </div>
                    </td>
                    </tr>
                    </table>

                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-5"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #000000; line-height: 1.5;"">
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">For your information and guidance.</span><br/><span style=""font-size:9px;"">Any concerns and clarification kindly inform the undersigned.</span><br/><span style=""font-size:9px;""><a href=""mailto:sdp-qa1systemdevt@sanyodenki.com"" style=""text-decoration: underline; color: #e5af88;"">sdp-qa1systemdevt@sanyodenki.com</a></span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">Local number: 154</span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">SANYO DENKI Philippines Inc.</span><br/><span style=""font-size:9px;"">QA1 System Automatic Email Notification</span></p>
                    </div>
                    </div>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </tbody>
                    </table>

                    </td>
                    </tr>
                    </tbody>
                    </table>
            
        
        
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tbody>
                    <tr>
                    <td>
                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;"" width=""680"">
                    <tbody>
                    <tr>
                    <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                    <div class=""spacer_block block-1"" style=""height:30px;line-height:30px;font-size:1px;""> </div>
                    <table border=""0"" cellpadding=""10"" cellspacing=""0"" class=""social_block block-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"">
                    <div align=""center"" class=""alignment"">

                    </div>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:5px;padding-top:5px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #393d47; line-height: 1.5;"">
                    <p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 21px;""><span style=""font-size:14px;color:#222222;"">QUALITY ASSURANCE 1 - SYSTEM AND MACHINE DEVELOPMENT</span></p>
                    </div>
                    </div>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""30"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #393d47; line-height: 1.5;"">
                    <p style=""margin: 0; font-size: 10px; text-align: center; mso-line-height-alt: 15px;""><span style=""font-size:10px;""><span><span style=""color:#222222;""> <br/></span></span><span style=""color:#999999;"">&copy; {yearNow}  Sanyo Denki Philippines. All Rights Reserved.</span></span></p>
                    </div>
                    </div>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </tbody>
                    </table>
                    </td>
                    </tr>
                    </tbody>
                    </table>

                    </body>
                    </html>";
        }
    }
}


