using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.Medicines.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Responses
{
    public class VetVisitResponse
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("animal")]
        public GeneralAnimalResponse generalAnimalResponse { get; set; }
        [JsonPropertyName("vet")]
        public GeneralVetResponse generalVetResponse { get; set; }
        [JsonPropertyName("medicines")]
        public IEnumerable<PrescribedMedicineResponse> prescribedMedicineResponses { get; set; }
        [JsonPropertyName("treatments")]
        public IEnumerable<TreatmentsResponse> treatmentsResponses { get; set; }


    }
}
