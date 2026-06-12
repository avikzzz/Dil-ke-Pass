using DilkePass.Application.Users.Interfaces;
using DilkePass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace DilkePass.Application.Users.Commands.CreatePrice
{
    public class CreatePriceHandler
    {
        private readonly IPriceRepository _priceRepository;
        private readonly ITourAttractionsRespository _tourRepository;
        private readonly IDilkePassDBContext _dbcontext;


        public CreatePriceHandler(IPriceRepository priceRepository, ITourAttractionsRespository tourRepos, IDilkePassDBContext dBContext)
        {
                

                _priceRepository = priceRepository;
                _tourRepository = tourRepos;
                _dbcontext = dBContext;
        }


        public async Task<int> CreatePriceAsync(CreatePriceCommand command)
        {
            var place = await _tourRepository.GetTourAttractionById(command.PlaceId);
            if (place == null)
                throw new KeyNotFoundException("place does not exist");
            var visitorType= await _priceRepository.GetVisitorType(command.VisitorType);
            if (visitorType == null)
                throw new KeyNotFoundException("visitor Type is invalid");

            // Start Transaction to prevent concurrency. Using Serializable Isolation level //serializable controls phantom read

            //await _unitofWork.BeginTransactionAsync(System.Transactions.IsolationLevel.Serializable);

            await using var transaction= await _dbcontext.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);

            try
            {
                var isExist = await _priceRepository.IsPriceExist(command.PlaceId, command.VisitorType, command.EffectiveDate, command.ExpiryDate);
                if (isExist)
                    throw new InvalidDataException("Price with this data already exists !!!");

                var price = Price.CreatePrice(
                    command.PlaceId, command.VisitorType, command.Price, command.EffectiveDate, command.ExpiryDate, command.CreatedBy
                    );

                await _priceRepository.CreatePriceAsync(price);

                // Now save in the DB

                await _dbcontext.SaveChangesAsync();

                // Now commit the transaction;

                await transaction.CommitAsync();

                // then return
                return price.Id;
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }         

            
           
            
            

            
        }
    }
}
