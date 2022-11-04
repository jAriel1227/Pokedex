using AutoMapper;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class GenericServices<SaveViewModel,ViewModel,Entity> : IGenericService<SaveViewModel, ViewModel,Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericServices(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _genericRepository = repository;
            _mapper = mapper;
        }  

        public async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);            

            entity = await _genericRepository.AddAsync(entity);

            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);           

            return saveVm;
        }
        public async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            
            await _genericRepository.UpdateAsync(entity,id);
        }       

        public async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);

            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
          
            return vm;
        }
        public async Task<List<ViewModel>> GetAllViewModel()
        {
            var entitiesList = await _genericRepository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(entitiesList);  
        }
        public async Task Delete(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            await _genericRepository.DeleteAsync(entity);
        }
    }
}
