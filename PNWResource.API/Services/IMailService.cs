﻿namespace PNWResource.API.Services
{
    public interface IMailService
    {
        void SendMail(string subject, string message);
    }
}