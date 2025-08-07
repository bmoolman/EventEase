using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventEase.Models;

namespace EventEase.Services
{
    public interface IEventService
    {
        List<EventModel> GetEvents();
        Task AddEventAsync(EventModel eventModel);
        Task UpdateEventAsync(EventModel eventModel);
        Task DeleteEventAsync(EventModel eventModel);
    }

    public class EventService : IEventService
    {
        private readonly List<EventModel> _events = new();

        public List<EventModel> GetEvents() => _events;

        public Task AddEventAsync(EventModel eventModel)
        {
            _events.Add(eventModel);
            return Task.CompletedTask;
        }

        public Task UpdateEventAsync(EventModel eventModel)
        {
            // Find and update the event in the collection
            var existingEvent = _events.Find(e => e.Id == eventModel.Id);
            if (existingEvent != null)
            {
                existingEvent.Name = eventModel.Name;
                existingEvent.Date = eventModel.Date;
                existingEvent.Location = eventModel.Location;
                existingEvent.EventUser = eventModel.EventUser;
                existingEvent.EventUserEmail = eventModel.EventUserEmail;
                existingEvent.HasAttended = eventModel.HasAttended;
            }
            return Task.CompletedTask;
        }

        public Task DeleteEventAsync(EventModel eventModel)
        {
            _events.Remove(eventModel);
            return Task.CompletedTask;
        }
    }
}