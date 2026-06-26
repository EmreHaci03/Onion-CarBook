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
    public class RemoveTestimonialHandler:IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public RemoveTestimonialHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
