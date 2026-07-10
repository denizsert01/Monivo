using AutoMapper;
using MediatR;
using Monivo.Application.Abstractions.Repositories;

namespace Monivo.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return;

            _mapper.Map(request, category);
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
