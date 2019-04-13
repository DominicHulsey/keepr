import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    addKeep(state, keep) {
      state.keeps.push(keep);
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    // #region keeps
    makeKeep({ commit, dispatch }, payload) {
      api.post("keeps", payload)
        .then(res => {
          commit("addKeep", res.data)
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get("keeps/")
        .then(res => {
          commit("setKeeps", res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete("keeps/" + payload)
        .then(res => {
          dispatch("getKeeps")
        })
    },
    // #endregion

  }
})
