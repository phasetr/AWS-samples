# django-copilot
## 参考記事
- [Original GitHub](https://github.com/aburayyanjeffry/django-copilot.git)
- [How to deploy a containerized Django app with AWS Copilot](https://www.endpointdev.com/blog/2022/06/how-to-deploy-containerized-django-app-with-aws-copilot/)
- [How to deploy a Django App with Aurora Serverless and AWS Copilot](https://www.endpointdev.com/blog/2022/06/how-to-deploy-django-app-with-aurora-serverless-and-copilot/)
## データベース切り替え
`settings.py`でデータベースの部分を書き換える.
## 最初の`Django`インストール
```
docker-compose run web django-admin startproject mydjango .
```

## コマンド
```
copilot init \
  -a apr-django \
  -t "Load Balanced Web Service" -n apr-django-web \
  -d ./Dockerfile
```

```
copilot env init \
  --name test \
  --profile default \
  --app apr-django \
  --default-config
```

```
copilot storage init \
  -n mydjango-db \
  -t Aurora -w \
  django-web \
  --engine PostgreSQL \
  --initial-db mydb
```

```
copilot deploy --name django-web
```

- [参考：`--noinput`](https://kamatimaru.hatenablog.com/entry/2021/02/28/030646)

```
copilot svc exec

# Dockerfileでスーパーユーザーの情報は環境変数に設定済み
python manage.py migrate
python manage.py createsuperuser --noinput
```

- [Django console](https://hodalog.com/how-to-use-django-shell/)

```
python manage.py shell

from django.contrib.auth.models import User
User.objects.get(username='admin')
```
