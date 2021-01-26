﻿using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BitrixService
{
	[ServiceContract]
	public interface IEmailService
	{
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		[OperationContract]
		Tuple<bool, string> SendEmail(Email mail);
	}
}
