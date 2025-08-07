using EventEase.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public interface ILocalStorageService
    {
        Task<bool> SaveEventsAsync(List<EventModel> events);
        Task<List<EventModel>> GetEventsAsync();
        Task<bool> SaveEventAsync(EventModel eventModel);
        Task<EventModel> GetEventAsync(Guid id);
        Task<bool> DeleteEventAsync(Guid id);
        Task<bool> IsAvailableAsync();
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string EventsKey = "events";

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> SaveEventsAsync(List<EventModel> events)
        {
            return await _jsRuntime.InvokeAsync<bool>("localStorageInterop.saveData", EventsKey, events);
        }

        public async Task<List<EventModel>> GetEventsAsync()
        {
            var events = await _jsRuntime.InvokeAsync<List<EventModel>>("localStorageInterop.getData", EventsKey);
            return events ?? new List<EventModel>();
        }

        public async Task<bool> SaveEventAsync(EventModel eventModel)
        {
            var events = await GetEventsAsync();
            var existingEventIndex = events.FindIndex(e => e.Id == eventModel.Id);
            
            if (existingEventIndex >= 0)
            {
                events[existingEventIndex] = eventModel;
            }
            else
            {
                events.Add(eventModel);
            }

            return await SaveEventsAsync(events);
        }

        public async Task<EventModel> GetEventAsync(Guid id)
        {
            var events = await GetEventsAsync();
            return events.Find(e => e.Id == id);
        }

        public async Task<bool> DeleteEventAsync(Guid id)
        {
            var events = await GetEventsAsync();
            var filteredEvents = events.Where(e => e.Id != id).ToList();
            return await SaveEventsAsync(filteredEvents);
        }

        public async Task<bool> IsAvailableAsync()
        {
            return await _jsRuntime.InvokeAsync<bool>("localStorageInterop.isAvailable");
        }
    }
}