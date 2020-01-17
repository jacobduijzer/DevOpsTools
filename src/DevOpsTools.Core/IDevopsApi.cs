using System.Threading.Tasks;
using DevOpsTools.Core.Models;
using Refit;

namespace DevOpsTools.Core
{
    public interface IDevopsApi
    {
        private const int DEFAULT_AMOUNT = 10;
        
        //definitions={definitionId}
        //https://dev.azure.com/{organization}/{project}/_apis/build/builds?api-version=5.1
        //&statusFilter=inProgress&
        [Get("/{project}/_apis/build/builds?$top={top}&statusFilter=inProgress,notStarted&api-version=5.0")]
        Task<CollectionResponse<Build>> GetBuildsAsync(string project, int top = DEFAULT_AMOUNT);

        //GET https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/releases?api-version=5.1
        [Get("/{project}/_apis/release/releases?$top={top}&$expand=environments&api-version=5.1")]
        Task<CollectionResponse<Release>> GetReleasesAsync(string project, int top = DEFAULT_AMOUNT);
        
        //GET https://vsrm.dev.azure.com/{organization}/{project}/_apis/release/releases?definitionId={definitionId}&definitionEnvironmentId={definitionEnvironmentId}&searchText={searchText}&createdBy={createdBy}&statusFilter={statusFilter}&environmentStatusFilter={environmentStatusFilter}&minCreatedTime={minCreatedTime}&maxCreatedTime={maxCreatedTime}&queryOrder={queryOrder}&$top={$top}&continuationToken={continuationToken}&$expand={$expand}&artifactTypeId={artifactTypeId}&sourceId={sourceId}&artifactVersionId={artifactVersionId}&sourceBranchFilter={sourceBranchFilter}&isDeleted={isDeleted}&tagFilter={tagFilter}&propertyFilters={propertyFilters}&releaseIdFilter={releaseIdFilter}&path={path}&api-version=5.1
        [Get("/{project}/_apis/release/deployments?$top={top}&deploymentStatus=inProgress&api-version=5.1")]
        Task<CollectionResponse<Deployment>> GetDeploymentsAsync(string project, int top = DEFAULT_AMOUNT);
    }
}