﻿using Domain.Entities.IdentityEntity;
namespace Domain.Entities.ChatEntity;

public class Message
{
    public Guid Id { get; set; }
    public bool IsRead { get; set; }
    public string AskerPhoneNumber { get; set; }
    public string ResponderPhoneNumber { get; set; }
    public string Content { get; set; }
    public string PictureUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public string GroupName { get; set; }
    
    
    public string AskerId { get; set; }
    public User Asker { get; set; }
    public string ResponderId { get; set; }
    public User Responder { get; set; }
    
    public Guid GroupId { get; set; }
    public Group Group { get; set; }

    public Message( string askerPhoneNumber, string responderPhoneNumber, string content, string pictureUrl, string askerId, string responderId, Guid groupId, string groupName)
    {
        IsRead = false;
        AskerPhoneNumber = askerPhoneNumber;
        ResponderPhoneNumber = responderPhoneNumber;
        Content = content;
        PictureUrl = pictureUrl;
        CreationDate = DateTime.Now;
        AskerId = askerId;
        ResponderId = responderId;
        GroupId = groupId;
        GroupName = groupName;
    }
}