using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class EventModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Event name is required")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public DateTime Date { get; set; } = DateTime.Today;
    
    [Required(ErrorMessage = "Event location is required")]
    public string Location { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Username must be between {2} and {1} characters", MinimumLength = 3)]
    [Display(Name = "Event Organizer")]
    public string EventUser { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Organizer Email")]
    public string EventUserEmail { get; set; } = string.Empty;
    
    [Display(Name = "Attended")]
    public bool HasAttended { get; set; } = false;

    public void Update(string name, DateTime date, string location, string user, string email, bool attended)
    {
        Name = name;
        Date = date;
        Location = location;
        EventUser = user;
        EventUserEmail = email;
        HasAttended = attended;
    }
}