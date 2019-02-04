var apiURL = 'https://localhost:44335/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading users...',
        users: null,
        currentUsers: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchUsers(); 
    },
    methods: {
        fetchUsers: function () {
            self = this;
            fetch(`${apiURL}Users/Basic`)
                .then(res => res.json())
                .then(function (users) {
                    users.forEach(function (user, i) {
                        user.isActive = false;
                    });
                    self.users = users;
                    self.message = 'Overview';
                    if (self.users.length > 0) {
                        self.fetchUserDetails(self.users[0]);
                    }
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchUserDetails: function (user) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${apiURL}Users/${user.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentUser = res;
                    self.makeUserActive(user.id);
                })
                .catch(err => console.error('Fout: ' + err));
        },
        makeUserActive: function (userid) {
            self.users.forEach(function (user, i) {
                user.isActive = user.id === userid ? true : false;
            });
        },

        getUserClass: function (user) {
            if (user.isActive) return 'list-group-item active';
            return 'list-group-item';
        },    
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentUser = { "firstName": "", "lastName": "", "birthDay": "" };
            }
        },
        save: function () {
            var self = this;

           // opslaan - ajax configuratie
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentUser),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${apiURL}Users/${self.currentUser.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateUserList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiURL}Users/`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addUserToList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
            window.location.reload(true); 
        },
        addUserToList: function (user) {              
            self.currentUser.id = user.id;
            self.users.push(user);
            self.fetchUserDetails(self.users[self.users.length - 1]);
        },
        updateUserList: function (user) {
            // de geupdate gebruiker uit de gebruikerslijst ophalen
            var updatedUser = self.users.filter(u => u.id === user.id)[0];
            // gegevens aanpassen
            updatedUser.firstName = user.firstName;   
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchUserDetails(self.currentUser);
            } else {
                self.fetchUserDetails(self.users[0]);
            }
        },
        deleteUser: function () {
            self = this;
            fetch(`${apiURL}Users/${self.currentUser.id}`, { method: 'DELETE' })
                .then(res => res.json())
                .then(function (res) {
                    // gebruiker verwijderen uit de lijst
                    self.users.forEach(function (user, i) {
                        if (user.id === self.currentUser.id) {
                            self.users.splice(i, 1);
                            return;
                        }
                    });
                    // eerste gebruiker selecteren
                    if (self.users.length > 0)
                        self.fetchUserDetails(self.users[0]);
                })
                .catch(err => console.error('Fout: ' + err));
        },
    }
});