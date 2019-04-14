// @ts-ignore
import Vue from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router'
import store from './store'
import MQ from 'vue-mq'
import { Drag, Drop } from 'vue-drag-drop';

Vue.config.productionTip = false

// @ts-ignore
Vue.component('drag', Drag);
// @ts-ignore
Vue.component('drop', Drop);

// @ts-ignore
Vue.use(MQ, {
  breakpoints: {
    xxs: 500,
    xs: 670,
    sm: 899,
    md: 991,
    lg: 1199
  }
})

// @ts-ignore
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
