﻿using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Email
{
	public class MessageModel
	{
		public List<MailboxAddress> To { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }

		public MessageModel(IEnumerable<string> to, string subject, string content)
		{
			To = new List<MailboxAddress>();

			To.AddRange(to.Select(x => new MailboxAddress(subject, x)));
			Subject = subject;
			Content = content;
		}
	}
}
