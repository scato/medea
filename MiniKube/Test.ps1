minikube image build . -f Test/Dockerfile --tag=medea/test --logtostderr

minikube kubectl -- delete -f .\MiniKube\jobs\test.yaml
minikube kubectl -- apply -f .\MiniKube\jobs\test.yaml

# follow logs, this will terminate once the job is finished
minikube kubectl -- logs jobs/medea-test --follow

$output = minikube kubectl -- get job medea-test -o json | ConvertFrom-Json

if ($output.status.failed -eq '1')
{
    throw "Test Run Failed."
}
