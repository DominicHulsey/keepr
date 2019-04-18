import Vue from 'vue'
import Vuex, { Store } from 'vuex'
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
    vaultkeeps: {},
    indexToDraw: [],
    imageArray: [],
    private: [],
    keepImages: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    addKeep(state, keep) {
      state.keeps.push(keep);
    },
    updateKeep(state, data) {
      state.keeps = state.keeps.map(old => {
        if (old.id == data.keep.id) {
          old[data.choice] = data.keep[data.choice]
          return old
        }
        return old
      })
      console.log(state.keeps)
    },
    addVault(state, vault) {
      state.vaults.push(vault);
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setPrivate(state, keeps) {
      state.private = keeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setVaultKeeps(state, allKeeps) {
      state.vaultkeeps[allKeeps.vaultId] = allKeeps.keeps
    },
    addToVault(state, vaultkeep) {
      state.vaultkeeps.find(vault => vault.vaultId == vaultkeep.vaultId).keeps = vaultkeep.keeps
    },
    addIndexes(state, imageArray) {
      state.indexToDraw.push(imageArray)
    },
    makeCollageImage(state, index) {
      let newObj = {
        image: state.keeps[index].img
      }
      state.imageArray.push(newObj)
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
          console.log(creds)
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
          // console.log(res.data)
          commit("addVault", res.data)
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get("keeps/")
        .then(res => {
          let toAdd = res.data.map(keep => {
            var image = new Image();
            image.src = keep.img;
            image.onload = function () {
              // @ts-ignore
              keep.width = this.width
              // @ts-ignore
              keep.height = this.height;
            }
            return keep
          })
          commit("setKeeps", toAdd)
        })
    },
    getPrivate({ commit, dispatch }) {
      api.get("keeps/private")
        .then(res => {
          let toAdd = res.data.map(keep => {
            var image = new Image();
            image.src = keep.img;
            image.onload = function () {
              // @ts-ignore
              keep.width = this.width
              // @ts-ignore
              keep.height = this.height;
            }
            return keep
          })
          console.log(toAdd)
          commit("setPrivate", toAdd)
        })
    },
    getVaults({ commit, dispatch }) {
      api.get("vaults/")
        .then(res => {
          commit("setVaults", res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, payload) {
      api.get("vaultkeeps/" + payload + '/keeps')
        .then(res => {
          let newPayload = {
            keeps: res.data,
            vaultId: payload
          }
          commit("setVaultKeeps", newPayload)
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
          dispatch("getVaults", payload)
        })
    },
    addCount({ commit, dispatch }, payload) {
      api.post("keeps/" + payload.keepData.id + "/" + payload.choice, payload.keepData)
        .then(res => {
          let newPayload = {
            keep: res.data,
            choice: payload.choice
          }
          commit("updateKeep", newPayload)
        })
    },
    addToVault({ commit, dispatch }, payload) {
      api.post("vaultkeeps/" + payload.vaultId, payload)
        .then(res => {
          dispatch("getVaultKeeps", payload.vaultId)
          dispatch("getVaults")
        })
    },
    remFromVault({ commit, dispatch }, payload) {
      api.delete("vaultkeeps/" + payload.vaultId + "/deletekeep/" + payload.keepId)
        .then(res => {
          dispatch("getVaultKeeps", payload.vaultId)
        })
    },
    numToDraw({ commit, dispatch }, payload) {
      let imageArray = []
      let finalArray = []
      let start = 0;
      let totalLength = payload
      for (let i = 0; i < totalLength / 5; i++) {
        if (start > totalLength - 5) {
          imageArray[1] = start + (totalLength - start);
        }
        else {
          imageArray[1] = start + 5;
        }
        imageArray[0] = start
        for (let i = imageArray[0]; i < imageArray[1]; i++) {
          commit("makeCollageImage", i)
        }
        let final = [imageArray[0], imageArray[1]]
        commit("addIndexes", final)
        start += 5;
      }
    }
    // #endregion

  },
  getters: {
    keeps: state => state.keeps,
  }
})
