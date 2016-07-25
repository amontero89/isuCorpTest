// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function AppViewModel() {

    this.contactName = ko.observable("");
    this.birthDate = ko.observable("");

    this.bodyTitle = ko.computed(function () {
        return this.contactName() + " " + this.birthDate();
    }, this);

    this.enableButton = ko.computed(function () {
        return !(this.contactName() == "" || this.birthDate() == "");
    }, this);


}

$(document).ready(function () {
    $('div.Editor-editor').attr('data-bind', 'text: bodyTitle');

    // Activates knockout.js
    ko.applyBindings(new AppViewModel());
});