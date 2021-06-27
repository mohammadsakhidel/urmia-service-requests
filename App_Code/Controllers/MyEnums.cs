using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEnums
{
    public enum Role
    {
        Administrator = 1,
        Operator = 2,
        Organization = 3,
        Supervisor = 4
    }

    public enum CompetitionType
    {
        Testi = 1,
        Tashrihi = 2
    }

    public enum RecievedMessageStatus
    {
        New = 1,
        Processed = 2
    }

    public enum RecievedMessageProcessResult
    {
        NotProcessed = 0,
        IncorrectFormat = 1,
        CorrectSuggestion = 2,
        NoActivePollExists = 3,
        IncorrectPollOptionSelected = 4,
        CorrectPollAnswer = 5,
        NoActiveCompetitionExists = 6,
        IncorrectCompetitionOptionSelected = 7,
        CorrectCompetitionAnswer = 8,
        CorrectPersuitCode = 9,
        IncorrectPersuitCode = 10,
        ServiceRequest = 11,
        IncorrectServiceCode = 12,
        FromService = 13
    }

    public enum RecievedMessageType
    {
        None = 0,
        Suggestion = 1,
        PollAnswer = 2,
        CompetitionAnswer = 3,
        Persuiting = 4,
        ServiceRequest = 5,
        MyAction = 6
    }

    public enum SuggestionStatus
    {
        NotRouted = 1,
        Routed = 2
    }

    public enum SuggestionRoutingStatus
    {
        Pending = 1,
        Rejected = 2,
        Verified = 3
    }

    public enum DateType
    {
        Short = 1,
        ShortWithTime = 2,
        Medium = 3,
        MediumWithTime = 4
    }

    public enum SentSmsStatus
    {
        Sent = 1,
        Delivered = 2
    }

    public enum TypeOfSend
    {
        Free = 1,
        ContactBook = 2
    }

    public enum AdvancedSearchCondition
    {
        Equal = 1,
        Fewer = 2,
        Greater = 3,
        Like = 4
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum TypeOfSuggestionSearch
    {
        Free = 1,
        Organization = 2
    }

    public enum AccessType
    {
        Read = 1,
        ReadWrite = 2,
        Hidden = 3
    }

    public enum SystemStatus
    {
        Running = 1,
        RunningWithError = 2,
        Stoped = 3
    }
}