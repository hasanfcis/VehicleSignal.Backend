using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleSignal.Domain.Entities;
using VehicleSignal.Domain.Interfaces.IRepositories;
using VehicleSignal.Domain.Interfaces.IServices;
using Xunit;

namespace VehicleSignal.Domain.Services.Test
{

    public class VehicleServiceTests
    {
        private IVehicleService _vehicleService;
        Mock<IVehicleRepository> _vehicleRepositoryMoq;
        public VehicleServiceTests()
        {
            _vehicleRepositoryMoq = new Mock<IVehicleRepository>();
        }

        [Fact]
        public void GetVehicles_Calling_ReturnDataIfExists()
        {
            _vehicleRepositoryMoq.Setup(m => m.GetVehicles()).Returns(new List<Vehicle>
            {
                new Vehicle()
                {
                    Id =1,Customer=new Customer {Id=1,Name="Kalles Grustransporter",Address="AB Cementvägen 8, 111 11 Södertälje" },
                    CustomerId =1,LastSignalTime=DateTime.Now,RegisterNumber="ABC123",
                    Status =new Status { Id=1,Name="Connected"},StatusId=1,VehicleIdentifier="YS2R4X20005399401"
                }
            });

            _vehicleService = new VehicleService(_vehicleRepositoryMoq.Object);

            var vs = _vehicleService.GetVehicles();
            vs.Should().NotBeEmpty();
        }

        [Fact]
        public void GetVehicles_Calling_ReturnEmptyDataIfDatesourceEmpty()
        {

            _vehicleRepositoryMoq.Setup(m => m.GetVehicles()).Returns(new List<Vehicle>
            {
            });

            _vehicleService = new VehicleService(_vehicleRepositoryMoq.Object);
            var vs = _vehicleService.GetVehicles();
            vs.Should().BeEmpty();
        }

        [Fact]
        public void UpdateVehicleStatus_Verifiy_Calling()
        {
            _vehicleRepositoryMoq.Setup(m => m.UpdateVehicleStatus(It.IsAny<long>(), It.IsAny<int>())).Verifiable();
        }

        [Theory]
        [InlineData(-1, 0)]
        public void UpdateVehicleStatus_VehicleId_NotExist_ThrowInvailOperationException(long vehicleId, int statusId)
        {
            _vehicleRepositoryMoq.Setup(m => m.UpdateVehicleStatus(vehicleId, statusId)).Throws<InvalidOperationException>();
            _vehicleService = new VehicleService(_vehicleRepositoryMoq.Object);

            Action updateAction = () => { _vehicleService.UpdateVehicleStatus(vehicleId, statusId); };
            updateAction.Should().Throw<InvalidOperationException>();

        }

        [Theory]
        [InlineData(1, 2)]
        public void UpdateVehicleStatus_StatusId_NotExist_DbUpdateException(long vehicleId, int statusId)
        {
            _vehicleRepositoryMoq.Setup(m => m.UpdateVehicleStatus(vehicleId, statusId)).Throws(new DbUpdateException(It.IsAny<string>(), It.IsAny<Exception>()));
            _vehicleService = new VehicleService(_vehicleRepositoryMoq.Object);

            Action updateAction = () => { _vehicleService.UpdateVehicleStatus(vehicleId, statusId); };
            updateAction.Should().Throw<DbUpdateException>();

        }

    }
}
