var apiURL = 'https://localhost:44335/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading registrations...',
        activities: null,
        participants: null,  
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchActivities(); 
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
                        self.fetchActivityParticipants(self.activities[0]);
                    }
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchActivityParticipants: function (activity) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${apiURL}Registrations`)
                .then(res => res.json())
                .then(function (registrations) { 
                    registrations.forEach(function (registration, i) {
                        if (self.registration.activityId == self.activity.id) {
                            self.participants.push(self.registration.userId); 
                        }
                    });
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
    }
});
