using AutoFixture;
using FluentAssertions;
using Tangerpay.Api.Services;
using Tangerpay.Api.Ports;
using Tangerpay.Domain.Entities;
using NSubstitute;

namespace Tangerpay.Api.Tests
{
    [TestFixture]
    public class ContactsServiceTests
    {
        private readonly Fixture _fixture = new();
        private Contact _contact = new();

        private readonly IContactsRepository mockContactsRepository = Substitute.For<IContactsRepository>();

        [SetUp]
        public void Setup()
        {
            _contact = _fixture.Create<Contact>();
        }

        [Test]
        public void CreateContact_CallsContactsRepositoryCreateContact()
        {
            var sut = MakeSut();

            _ = sut.CreateContact(_contact);

            mockContactsRepository.Received(1).CreateContact(_contact);
        }

        [Test]
        public void CreateContact_RecordsContactAndReturnsContactId()
        {
            var expectedContactId = 2;
            mockContactsRepository.CreateContact(_contact).Returns(expectedContactId);
            
            var sut = MakeSut();

            var actualContactId = sut.CreateContact(_contact);

            actualContactId.Should().Be(expectedContactId);
        }

        [Test]
        public void GetContact_CallsContactsRepositoryGetContact()
        {
            var sut = MakeSut();

            _ = sut.GetContact(_contact.Id);

            _ = mockContactsRepository.Received(1).GetContact(_contact.Id);
        }

        [Test]
        public void GetContact_RetrievesContact()
        {
            var expectedContact = new Contact
            {
                Name = "John Smith",
                PhoneNumber = "61234567890"
            };
            mockContactsRepository.GetContact(_contact.Id).Returns(expectedContact);

            var sut = MakeSut();

            var actualContact = sut.GetContact(_contact.Id);

            actualContact.Name.Should().Be(expectedContact.Name);
            actualContact.PhoneNumber.Should().Be(expectedContact.PhoneNumber);
        }

        private ContactsService MakeSut()
        {
            return new ContactsService(mockContactsRepository);
        }
    }
}