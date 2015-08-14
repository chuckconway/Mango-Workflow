**Usage**


    WorkFlow
        .If((() => !hasPendingAOM))
        .If((() => (groupMember.Member.Relationship == "S" || groupMember.Member.Relationship == "I"))) //check to see if the person is the Employee or the Spouse
        .If(() => !string.Equals(oldValue, newValue, StringComparison.InvariantCultureIgnoreCase) && newValue == "M") //Check to see if the status has changed. If it's changed and now it's married, then move forward.
        .If(() => groupMember.EmployerGroup.GroupSize > 20)
        .If(() => groupMember.EmployerGroup.AdministratorOfCOBRA)
        .DoIf(() => groupMember.Member.Addresses.Any(), () =>
        {
            _bus.Send(new CreateCobraNotificationMessage
            {
                Member = groupMember.Member,
                Reason = "Member's martial status has changed."
            });
        })
        .DoElse(() =>
        {
            _bus.Send(new ErrorCobraNotificationMessage
            {
                Member = groupMember.Member,
                Reason = "Member does not have address on record."
            });
        });