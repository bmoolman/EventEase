// LocalStorage interop functions for Blazor
window.localStorageInterop = {
    // Save data with specified key
    saveData: function (key, data) {
        if (data) {
            localStorage.setItem(key, JSON.stringify(data));
            return true;
        }
        return false;
    },

    // Get data by key
    getData: function (key) {
        const item = localStorage.getItem(key);
        return item ? JSON.parse(item) : null;
    },

    // Remove data by key
    removeData: function (key) {
        localStorage.removeItem(key);
        return true;
    },

    // Save an array of events
    saveEvents: function (events) {
        if (events) {
            localStorage.setItem('events', JSON.stringify(events));
            return true;
        }
        return false;
    },

    // Get all events
    getEvents: function () {
        const events = localStorage.getItem('events');
        return events ? JSON.parse(events) : [];
    },

    // Check if localStorage is available
    isAvailable: function () {
        try {
            const x = '__storage_test__';
            localStorage.setItem(x, x);
            localStorage.removeItem(x);
            return true;
        } catch (e) {
            return false;
        }
    }
};