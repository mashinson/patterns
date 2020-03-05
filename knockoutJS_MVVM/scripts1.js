var initialData = [{
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  },
  {
    sender: "Mary",
    chatName: "Mary", 
    appType: "kik", 
    contentType: "image", 
    creationDate: "2019-09-03", 
    body: "dkdkdksmfd kdfmsdkfmdfkmsdf dmffmdfmdmfdkfdfd df,fdlfdfdf", 
    messageType: "info", 
    visiableDate: "5 minutes ago"
  }
];

var MessageItem = function(dataItem) {
  var self = this;
  self.sender = dataItem.sender;
  self.chatName = dataItem.chatName;
  self.appType = dataItem.appType;
  self.contentType = dataItem.contentType;
  self.creationDate = dataItem.creationDate;
  self.body = dataItem.body;
  self.messageType = dataItem.messageType;
  self.visiableDate = dataItem.visiableDate;
};

var AppMonitoringViewModel = function(items) {
  var self = this;
  self.items = ko.observableArray();
  for (var i = 0; i < items.length; i++) {
    self.items().push(new MessageItem(items[i]));
  };
  
};

ko.applyBindings(new AppMonitoringViewModel(initialData));
