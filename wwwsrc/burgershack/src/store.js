import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import Axios from 'axios';

var server = Axios.create({
  baseURL: "//localhost:5000/api/"
})

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    burgers: []
  },
  mutations: {
    setBurgers(state, burgers) {
      state.burgers = burgers;
    }
  },
  actions: {
    getAllBurgers({ commit, dispatch }) {
      server.get('burgers')
        .then(res => {
          commit('setBurgers', res.data)
        })
    }
  }
})
