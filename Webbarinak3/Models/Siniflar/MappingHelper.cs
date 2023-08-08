using Webbarinak3.Models.Siniflar;

namespace Webbarinak3.Helpers
{
    public static class MappingHelper
    {
        public static Animal MapRequestToAnimal(Request2 request)
        {
            // Request2 nesnesinden Animal nesnesine veri aktarımı yapma
            var animal = new Animal
            {
                Turu = request.Turu,
                Cinsi = request.Cinsi,
                Yasi = request.Yasi,
                SaglikDurumu = request.SaglikDurumu
            };

            return animal;
        }
    }
}
