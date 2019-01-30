var apiURL = 'https://localhost:44335/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading...',
        activities: null,
        categories: null,
        countries: null,
        currentActivity: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchActivities();
        self.fetchCategories();
        self.fetchCountries();
    },
    methods: {
        fetchActivities: function () {
            self = this;
            fetch(`${apiURL}Activities/Basic`)
                .then(res => res.json())
                .then(function (activities) {
                    activities.forEach(function (activity, i) {
                        activity.isActive = false;
                    });
                    self.activities = activities;
                    self.message = 'Overview';
                    if (self.activities.length > 0) {
                        self.fetchActivityDetails(self.activities[0]);
                    }
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchActivityDetails: function (activity) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${apiURL}Activities/${activity.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentActivity = res;
                    self.makeActivityActive(activity.id);
                })
                .catch(err => console.error('Fout: ' + err));
        },
        makeActivityActive: function (activityid) {
            self.activities.forEach(function (activity, i) {
                activity.isActive = activity.id === activityid ? true : false;
            });
        },
        getActivityClass: function (activity) {
            if (activity.isActive) return 'list-group-item active';
            return 'list-group-item';
        },
        fetchCategories: function () {
            self = this;
            fetch(`${apiURL}Categories`)
                .then(res => res.json())
                .then(function (res) {
                    self.categories = res;
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchCountries: function () {
            self = this;
            fetch(`${apiURL}Countries`)
                .then(res => res.json())
                .then(function (res) {
                    self.countries = res;
                })
                .catch(err => console.error('Fout: ' + err));
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentActivity = { "title": "", "description": "", "startDateTime": "", "stopDateTime": "", "categoryId": 0, "category": { "categoryName": "", "id": 0, "created": "" }, "countryId": 0, "country": { "countryName": "", "id": 0, "created": "" } };
            }
        },
        save: function () {
            var self = this;

            // de properties categoryId en countryId van de Activity zijn nog leeg
            // de vue.js databinding vult enkel de compositeproperties category en country
            self.currentActivity.categoryId = self.currentActivity.category.id;
            self.currentActivity.countryId = self.currentActivity.country.id;

            // opslaan - ajax configuratie
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentActivity),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${apiURL}Activities/${self.currentActivity.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateActivityList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiURL}Activities/`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addActivityToList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addActivityToList: function (activity) {  
            self.currentActivity.id = activity.id;
            self.activities.push(activity);
            self.fetchActivityDetails(self.activities[self.activities.length - 1]);
        },
        updateActivityList: function (activity) {
            // de geupdate activiteit uit de activiteitenlijst ophalen
            var updatedActivity = self.activities.filter(a => a.id === activity.id)[0];
            // gegevens aanpassen
            updatedActivity.title = activity.title;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchActivityDetails(self.currentActivity);
            } else {
                self.fetchActivityDetails(self.activities[0]);
            }
        },
        deleteActivity: function () {
            self = this;
            fetch(`${apiURL}Activities/${self.currentActivity.id}`, { method: 'DELETE' })
                .then(res => res.json())
                .then(function (res) {
                    // activiteit verwijderen uit de lijst
                    self.activities.forEach(function (activity, i) {
                        if (activity.id === self.currentActivity.id) {
                            self.activities.splice(i, 1);
                            return;
                        }
                    });
                    // eerste activiteit selecteren
                    if (self.activities.length > 0)
                        self.fetchActivityDetails(self.activities[0]);
                })
                .catch(err => console.error('Fout: ' + err));
        },     
    }
});
