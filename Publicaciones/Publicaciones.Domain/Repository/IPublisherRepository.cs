using System;
using System.Collections.Generic;
using Publicaciones.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Domain.Repository
{
    public interface IPublisherRepository
    {
        void Save(Publisher publisher);
        void Update(Publisher publisher);
        void Remove(Publisher publisher);
        List<Publisher> GetPublishers();
        Publisher GetPublisherID(string ID);

    }
}
