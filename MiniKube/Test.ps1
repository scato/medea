minikube image build . -f Test/Dockerfile --tag=medea/test --logtostderr

minikube kubectl -- delete -f ./MiniKube/jobs/test.yaml
minikube kubectl -- apply -f ./MiniKube/jobs/test.yaml

$active = minikube kubectl -- get job medea-test --output=jsonpath='{.status.active}'
while ($active -eq '1')
{
    Start-Sleep 1
    Write-Output "Waiting for medea-test to finish..."
    $active = minikube kubectl -- get job medea-test --output=jsonpath='{.status.active}'
}

minikube kubectl -- logs job/medea-test

$failed = minikube kubectl -- get job medea-test --output=jsonpath='{.status.failed}'

if ($failed -eq '1')
{
    throw "Test Run Failed."
}
