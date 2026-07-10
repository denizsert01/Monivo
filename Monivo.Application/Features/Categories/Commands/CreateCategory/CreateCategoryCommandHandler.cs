using AutoMapper;
using MediatR;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
