// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function AppViewModel() {

    this.contactName = ko.observable($('#ContactName').val());
    this.birthDate = ko.observable($('#BirthDate').val());

    this.enableButton = ko.computed(function () {
        return !(this.contactName() == "" || this.birthDate() == "");
    }, this);
    
}

// Activates knockout.js
ko.applyBindings(new AppViewModel());
