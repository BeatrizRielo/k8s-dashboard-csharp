using System.Linq;
using System.Threading.Tasks;
using k8s;
using KubernetesApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesApi.Web.Controllers
{
    public class ServiceController : Controller
    {
        private IKubernetes _k8s;
        public ServiceController(IKubernetes k8s)
        {
            this._k8s = k8s;
        }

        public IActionResult Index([FromQuery] string ns = "default")
        {
            var serviceList = this._k8s.ListNamespacedService(ns);

            var viewModel = serviceList.Items.Select(serviceItem => new ServiceViewModel()
            {
                Name = serviceItem.Metadata.Name,
                Namespace = serviceItem.Metadata.NamespaceProperty,
                ClusterIP = serviceItem.Spec.ClusterIP,
                Ports = serviceItem.Spec.Ports.Select(p => p.Port).ToList()
            }).ToList();

            return View(viewModel);
        }
    }
}