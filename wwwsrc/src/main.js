import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import MQ from 'vue-mq'
import { Drag, Drop } from 'vue-drag-drop';

Vue.config.productionTip = false

Vue.component('drag', Drag);
Vue.component('drop', Drop);

Vue.use(MQ, {
  breakpoints: {
    xs: 575,
    sm: 767,
    md: 991,
    lg: 1199
  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
