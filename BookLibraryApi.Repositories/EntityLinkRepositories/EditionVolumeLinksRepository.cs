﻿using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Models.EntityLinks;

namespace BookLibraryApi.Repositories.EntityLinkRepositories
{
    public sealed class EditionVolumeLinksRepository : EntityRepositoryBase<EditionVolumeLink>
    {
        public EditionVolumeLinksRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
