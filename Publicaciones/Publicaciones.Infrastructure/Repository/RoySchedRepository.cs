using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class RoySchedRepository : BaseRepository<RoySched>, IRoySchedRepository
    {
        private readonly PublicacionesContext context;
        public RoySchedRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public bool Exists(int roySchedId)
		{
			return base.Exists(rs => rs.RoySched_ID == roySchedId);
		}
		public bool ExistsInTitles(int titleId)
		{
			return this.context.Set<Titles>().Any(t => t.Title_ID == titleId);
		}

		public List<RoySched> GetRoySchedsByRoyalty(int royalty)
		{
			return this.context.RoySched.Where(r => r.Royalty == royalty).ToList();
		}

		public override List<RoySched> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted)
				.OrderByDescending(st => st.CreationDate)
										.ToList();
		}

		public override void Save(RoySched entity)
		{
			context.RoySched.Add(entity);
			context.SaveChanges();
		}

		public override void Update(RoySched entity)
		{
			var roySchedToUpdate = base.GetEntityByID(entity.RoySched_ID);

			roySchedToUpdate.Title_ID = entity.Title_ID;
			roySchedToUpdate.Royalty = entity.Royalty;
			roySchedToUpdate.HiRange = entity.HiRange;
			roySchedToUpdate.LoRange = entity.LoRange;
			roySchedToUpdate.ModifiedDate = entity.ModifiedDate;
			roySchedToUpdate.IDModifiedUser = entity.IDModifiedUser;

			context.RoySched.Update(roySchedToUpdate);
			context.SaveChanges();
		}

		public override void Remove(RoySched entity)
		{
			var roySchedToRemove = base.GetEntityByID(entity.RoySched_ID);

			roySchedToRemove.RoySched_ID = entity.RoySched_ID;
			roySchedToRemove.Deleted = entity.Deleted;
			roySchedToRemove.DeletedDate = entity.DeletedDate;
			roySchedToRemove.IDDeletedUser = entity.IDDeletedUser;

			this.context.RoySched.Update(roySchedToRemove);
			this.context.SaveChanges();

		}

		public List<RoySchedTitleModel> GetRoySchedsByTitleID(int titleId)
		{
			return this.GetRoySchedsTitles().Where(rt => rt.TitleID == titleId).ToList();
		}

		public List<RoySchedTitleModel> GetRoySchedsTitles()
		{
			var roySched = (from rs in this.GetEntities()
							 join tt in this.context.Titles on rs.Title_ID equals tt.Title_ID
							 where !rs.Deleted
							 select new RoySchedTitleModel()
							 {
								 RoySchedID = rs.RoySched_ID,
								 TitleID = rs.Title_ID,
								 Title = tt.Title,
								 Royalty = tt.Royalty,
								 HiRange = rs.HiRange,
								 LoRange = rs.LoRange,
								 CreationDate = rs.CreationDate
							 }).ToList();

			return roySched;
		}

		public RoySchedTitleModel RoySchedTitle(int royId)
		{
			return this.GetRoySchedsTitles().SingleOrDefault(rt  => rt.RoySchedID == royId);
		}
	}
}
