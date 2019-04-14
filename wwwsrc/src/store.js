import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import { stat } from 'fs';

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
    keeps: [],
    vaults: [],
    vaultkeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    addKeep(state, keep) {
      state.keeps.push(keep);
    },
    addVault(state, vault) {
      state.vaults.push(vault);
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps;
    },
    addToVault(state, vaultkeep) {
      state.vaultkeeps.push(vaultkeep)
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
    makeVault({ commit, dispatch }, payload) {
      api.post("vaults", payload)
        .then(res => {
          console.log(res.data)
          commit("addVault", res.data)
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get("keeps/")
        .then(res => {
          commit("setKeeps", res.data)
        })
    },
    getVaults({ commit, dispatch }) {
      api.get("vaults/")
        .then(res => {
          commit("setVaults", res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, payload) {
      api.get("vaultkeeps/" + payload, payload)
        .then(res => {
          console.log(res.data)
          commit("setVaultKeeps", res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete("keeps/" + payload)
        .then(res => {
          dispatch("getKeeps")
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete("vaults/" + payload)
        .then(res => {
          dispatch("getVaults")
        })
    },
    addToVault({ commit, dispatch }, payload) {
      api.post("vaultkeeps/" + payload.vaultId, payload)
        .then(res => {
          console.log(res.data)
          commit("addToVault", res.data)
        })
    }
    // #endregion

  }
})
