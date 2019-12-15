# Build docker image

'docker build -t medifii/api-gateway:v1 .'

kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/master/deploy/static/mandatory.yaml

'kubectl apply -f .\service.yaml'
'kubectl apply -f .\deployment.yaml'
'kubectl apply -f .\ingress.yaml'