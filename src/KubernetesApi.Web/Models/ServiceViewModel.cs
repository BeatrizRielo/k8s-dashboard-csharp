using System.Collections.Generic;

namespace KubernetesApi.Web.Models
{
    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string ClusterIP { get; set; }
        public List<int> Ports { get; set; }
    }
}