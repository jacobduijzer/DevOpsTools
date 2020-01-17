using System.Collections.Generic;
using System.Linq;

namespace DevOpsTools.Core.Models
{
    public class Environment
    {
        public int Id { get; set; }

        public int DefinitionEnvironmentId { get; set; }

        public int ReleaseId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Approval> PreDeployApprovals { get; set; }

        public string Status { get; set; }

        public string State { get; set; }
    }
}