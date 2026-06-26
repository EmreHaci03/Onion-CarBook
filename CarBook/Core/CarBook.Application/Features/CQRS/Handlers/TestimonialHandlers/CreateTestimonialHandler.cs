using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public CreateTestimonialHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values=_mapper.Map<Testimonial>(request);
            await _repository.CreateAsync(values);
   
        }
    }
}
