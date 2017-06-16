var ViewModel = function () {
    var self = this; // make 'this' available to subfunctions or closures
    self.users = ko.observableArray(); // enables data binding

    var usersUri = "/api/users";
    function getAllUsers() {
        $.getJSON(usersUri).done(function (data) {
            self.users(data);
        });
    }
    // Fetch the initial data
    getAllUsers();

    //self.currUser = ko.observable();
    //self.getUserDetails = function (user) {
    //    $.getJSON(usersUri + "/" + user.Id).done(function (data) {
    //        self.currUser(data);
    //    });
    //}
};
ko.applyBindings(new ViewModel()); // sets up the data binding
