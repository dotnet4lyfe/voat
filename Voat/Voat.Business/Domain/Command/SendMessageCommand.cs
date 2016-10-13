﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voat.Data;
using Voat.Domain.Models;

namespace Voat.Domain.Command
{
    public class SendMessageCommand : Command<CommandResponse<Message>>
    {
        private SendMessage _message;
        private bool _forceSend;

        public SendMessageCommand(SendMessage message, bool forceSend = false)
        {
            this._message = message;
            this._forceSend = forceSend;
        }

        protected override async Task<CommandResponse<Message>> ProtectedExecute()
        {
            using (var repo = new Repository())
            {
                return await Task.Run(() => repo.SendMessage(_message, _forceSend));
            }
        }
    }
    public class SendMessageReplyCommand : Command<CommandResponse<Message>>
    {
        private string _message;
        private int _messageID;

        public SendMessageReplyCommand(int messageID, string message)
        {
            this._message = message;
            this._messageID = messageID;
        }

        protected override async Task<CommandResponse<Message>> ProtectedExecute()
        {
            using (var repo = new Repository())
            {
                return await Task.Run(() => repo.SendMessageReply(_messageID, _message));
            }
        }
    }
}
