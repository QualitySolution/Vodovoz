﻿using System;
using QS.Project.Journal;
using Vodovoz.Domain.Orders;

namespace Vodovoz.JournalNodes
{
	public class PromotionalSetJournalNode : JournalEntityNodeBase<PromotionalSet>
	{
		public bool IsArchive { get; set; }

		public string IsArchiveString => IsArchive ? "Да" : "";
		public string RowColor => IsArchive ? "grey" : "black";
		public string Name { get; set; }
		public string PromoSetDiscountReasonName { get; set; }
	}
}
