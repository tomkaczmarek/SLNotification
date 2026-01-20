using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class Notification
    {
        public IntId Id { get; set; }
        public GuidId RecipientId { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public Body NoticationBody { get; set; }
        public BoolField IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification(GuidId recipientId, NotificationTypes notificationType, Body noticationBody, BoolField isActive)
        {
            RecipientId = recipientId;
            NotificationType = notificationType;
            NoticationBody = noticationBody;
            IsActive = isActive;
        }
    }

    public enum NotificationTypes
    {
        BandAcceptMembershipForMembersBand,
        BandAcceptMembership,
        BandInviteFromBand,
        BandInviteFromUser,
        BandRejectBandInvite,
        BandRejectMemberInvite,
        BandMemberInfoAcceptMembershipNotification,
        BandMemberInfoRejectMemberInviteNotification,
        BandCreateNewInfo,
        BandYouJoinToInfo,
        AlbumInviteMemberToAlbum,
        AlbumSourceAcceptInviteToAlbum,
        AlbumMemberInfoAcceptBySourceNotification,
        AlbumMemberInfoAcceptByProfileNotification,
        AlbumMemberInfoRejectMemberInviteNotification,
        AlbumProfileAcceptInviteToAlbum,
        EventPublishEventNotification,
        EventInviteMemberNotification,
        EventMemberAcceptInviteNotification,
        EventNotifyMembersWhenNewMemberAcceptInviteNotification
    }

    public enum DomainObjectsType
    {
        Artist,
        Publisher,
        School,
        PublicOrganization,
        RecordingStudio,
        Follower,
        Band,
        Event,
        Album,
        FakeArtist,
        Unknow = 99
    }
}
