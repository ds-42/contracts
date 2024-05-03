using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Application.Extensions;

public static class OrgAdminExtension
{
    public static Org GetOrg(this IBaseReadRepository<OrgAdmin> orgs, int orgId, int userId)
    {
        var rec = orgs.AsQueryable()
            .Include(t => t.Org)
            .FirstOrDefault(t => t.OrgId == orgId && t.UserId == userId);

        if (rec == null)
            throw new AccessDeniedException();

        return rec.Org!;
    }

}
