using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface ISehirService : IService<SehirModel, Sehir, ETicaretContext>
    {
        Result<List<SehirModel>> List();
    }

    public class SehirService : ISehirService
    {
        public RepoBase<Sehir, ETicaretContext> Repo { get; set; } = new Repo <Sehir, ETicaretContext>();

        public Result Add(SehirModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<SehirModel> Query()
        {
            return Repo.Query("Ulke").OrderBy(s => s.Adi).Select(s => new SehirModel()
            {
                Adi = s.Adi,
                Id = s.Id,
                UlkeId = s.UlkeId,

                UlkeAdiDisplay = s.Ulke.Adi
            });
        }

        public Result Update(SehirModel model)
        {
            throw new NotImplementedException();
        }

        public Result<List<SehirModel>> List()
        {
            var list = Query().ToList();
            if (list.Count == 0)
                return new ErrorResult<List<SehirModel>>("Şehir bulunamadı!");
            return new SuccessResult<List<SehirModel>>(list.Count + " adet şehir bulundu.", list);
        }
    }
}
