using System.Linq;

namespace Vodovoz.Domain.Orders.Documents.AssemblyList {
    public class AssemblyListDocumentUpdater : OrderDocumentUpdaterBase {

        private readonly AssemblyListDocumentFactory documentFactory;
        
        public override OrderDocumentType DocumentType => OrderDocumentType.AssemblyList;

        public AssemblyListDocumentUpdater(AssemblyListDocumentFactory documentFactory) {
            this.documentFactory = documentFactory;
        }

        private AssemblyListDocument CreateNewDocument() {
            return documentFactory.Create();
        }

        private bool NeedCreateDocument(OrderBase order) {
            if(order is IEShopOrder eShopOrder)
               return eShopOrder.EShopOrder.HasValue;
            
            return false;
        }

        public override void UpdateDocument(OrderBase order) {
            if (NeedCreateDocument(order)) {
                AddNewDocument(order, CreateNewDocument());
            }
            else {
                RemoveDocument(order);
            }
        }

        public override void AddExistingDocument(OrderBase order, OrderDocument existingDocument) {
            if (!order.ObservableOrderDocuments.Any(x => x.NewOrder.Id == order.Id && x.Type == existingDocument.Type)) {
                var doc = CreateNewDocument();
                doc.NewOrder = existingDocument.NewOrder;
                doc.AttachedToNewOrder = order;
                order.ObservableOrderDocuments.Add(doc);
            }
        }

        public override void RemoveExistingDocument(OrderBase order, OrderDocument existingDocument) {
            RemoveDocument(order, existingDocument);
        }
    }
}