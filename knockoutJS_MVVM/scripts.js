var initialData = [{
    name: "Well-Travelled Kitten",
    price: 75.95
  },
  {
    name: "Speedy Coyote",
    price: 190.00
  },
  {
    name: "Furious Lizard",
    price: 25.00
  },
  {
    name: "Indifferent Monkey",
    price: 99.95
  },
  {
    name: "Brooding Dragon",
    price: 6350
  },
  {
    name: "Ingenious Tadpole",
    price: 0.35
  },
  {
    name: "Optimistic Snail",
    price: 1.50
  }
];

var ProductItem = function(dataItem) {
    debugger;
  var self = this;
  self.name = dataItem.name;
  self.price = dataItem.price;
  self.inputValue = ko.observable(1);
}

var CartItem = function(item) {
  var self = this;
  self.item = ko.observable(item);
  self.count = ko.observable(item.inputValue());
  self.subtotal = ko.pureComputed(function() {
    return self.item().price * self.count();
  });
}

var PagedListModel = function(items) {
  var self = this;
  self.items = ko.observableArray();
  for (var i = 0; i < items.length; i++) {
    self.items().push(new ProductItem(items[i]));
  }
  self.cart = ko.observableArray();

  self.addToCart = function(item) {
    var itemInCart = self.cart().find(function(arrItem, index, array) {
      return arrItem.item().name == item.name;
    });
    if (itemInCart) {
      itemInCart.count(Number(itemInCart.count()) + Number(item.inputValue()));
    } else {
      self.cart.push(new CartItem(item));
    }
    item.inputValue(1);
  }

  self.totalPrice = ko.pureComputed(function() {
    var total = 0;
    $.each(self.cart(), function() {
      total += this.subtotal();
    })
    return total;
  });

  self.totalCount = ko.pureComputed(function() {
    var total = 0;
    $.each(self.cart(), function() {
      total += Number(this.count());
      console.log(total);
    })
    console.log(total);
    return total;
  });

};

ko.applyBindings(new PagedListModel(initialData));
