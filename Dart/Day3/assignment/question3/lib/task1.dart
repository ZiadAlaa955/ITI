class InvoiceItem {
  final String descriptor;
  final double cost;
  final double fee;
  final double total;

  InvoiceItem(this.descriptor, this.cost, this.fee) : total = cost + fee;

  static double calculateTax(double amount) {
    return amount * 0.14;
  }
}

void task1() {
  InvoiceItem invoiceItem = InvoiceItem("descriptor", 1000, 55);
  print(InvoiceItem.calculateTax(invoiceItem.total));
}
