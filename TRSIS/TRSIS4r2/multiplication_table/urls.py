from django.contrib import admin
from django.urls import path
from multiplication_table_app import views

urlpatterns = [
    path('admin/', admin.site.urls),
    path('', views.index, name='index'),
    path('compose/', views.compose),
    path('compose/<str:shortcut>/<str:quant>/<str:num>/', views.fill, name='ask'),
    path('compose/<str:shortcut>/confirm/', views.confirm, name='confirm'),
    path('take/', views.take),
]
